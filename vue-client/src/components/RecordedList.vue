<template>
  <h1>Recorded Songs</h1>
  <div class="tbl-header">
    <table cellpadding="0" cellspacing="0">
      <thead>
        <tr>
          <th>Index</th>
          <th>Title</th>
          <th>Date Of Creation</th>
          <th></th>
          <th></th>
        </tr>
      </thead>
    </table>
  </div>
  <div class="tbl-content">
    <table cellpadding="0" cellspacing="0">
      <tbody v-for="(song, index) in songs" :key="index">
        <tr>
          <td>{{ index + 1 }} </td>
          <td> {{ song.title }}</td>
          <td>{{ new Date(song.created).toLocaleString() }}</td>          
          <td class="st_column_action">
            <audio
              ref="audioPlayer"
              id="audioPlayer"
              controls
              :src="'https://localhost:7089/api/Audio/audio/' + song.title + '.webm'"             
            ></audio>
          </td>
          <td>    
            <button class="board_button" @click="downloadAudio(song.title)">
              <img src="../assets/download.png" />            
            </button>         
            <button class="board_button" @click="deleteSong(song.id, index)">
              <img src="../assets/garbage.png" />
            </button>
          </td>        
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { makeApiRequest } from "../utils/useFetch";
import { recording } from "./CreateRecordPopup.vue";
export default {
  data() {
    return { songs: [] };
  },

  async mounted() {
    let userId = await this.getUserId();
    this.getSongs(userId);
  },

  methods: {
    async getUserId() {
      let userId;

      let url = `https://localhost:7089/api/Auth/user`;
      let options = {
        headers: {
          "Content-Type": "application/json",
        },
        method: "GET",
        credentials: "include",
      };

      const { responseFlag, responseData } = await makeApiRequest(url, options);
      if (responseFlag) {
        userId = responseData.id;
      }
      return userId;
    },

    changeDateTime(time)
    {
      var date = new Date(time);
      return date;
    },

    async getSongs(userId) {
      let url = `https://localhost:7089/api/Audio/${userId}`;
      const options = {
        headers: {
          "Content-Type": "application/json",
        },
        method: "GET",
        body: JSON.stringify(this.newUser),
      };

      const { responseFlag, responseData } = await makeApiRequest(url, options);
      if (responseFlag) {
        this.songs = responseData;
      }
    },

    async deleteSong(id, index) {
      let url = `https://localhost:7089/api/Audio/${id}`;
      const options = {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      };

      const { responseFlag, responseData } = await makeApiRequest(url, options);
      if (responseFlag) {
        this.songs.splice(index, 1);
      }
    },

    async downloadAudio(audioFileName) {
      try {
        const response = await fetch(`https://localhost:7089/api/Audio/audio/${audioFileName}.webm`);
        
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const blob = await response.blob();

        // Create a blob URL for the downloaded file
        const blobURL = window.URL.createObjectURL(blob);

        // Create a temporary anchor element for downloading
        const anchor = document.createElement('a');
        anchor.href = blobURL;
        anchor.download = audioFileName;

        // Simulate a click on the anchor element to trigger the download
        anchor.click();

        // Clean up the anchor and revoke the blob URL
        window.URL.revokeObjectURL(blobURL);
      } catch (error) {
        console.error('Error downloading audio:', error);
      }
    },
  },
};
</script>

<style lang="scss">
/////////////////////
h1{
  font-size: 25px;
  color: #fff;
  font-weight: 300;
  text-align: center;
  margin-bottom: 15px;
}
.board_button  {
  background: transparent;
  border: transparent;
  cursor: pointer;
  margin-right: 20px;
}

.board_button img {
  width:20px;
  margin-top: 5px;
}

table{
  width:100%;
  table-layout: fixed;
}
.tbl-header{
  background-color: rgba(255,255,255,0.3);
 }
.tbl-content{
  height:250px;
  overflow-x:auto;
  margin-top: 0px;
  border: 1px solid rgba(255,255,255,0.3);
}
th{
  padding: 20px 15px;
  text-align: left;
  font-weight: 500;
  font-size: 12px;
  color: #fff;
  text-transform: uppercase;
}
td{
  padding: 10px;
  text-align: left;
  vertical-align:middle;
  font-weight: 300;
  font-size: 12px;
  color: #fff;
  border-bottom: solid 1px rgba(255,255,255,0.1);
}


/* for custom scrollbar for webkit browser*/

::-webkit-scrollbar {
    width: 6px;
} 
::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3); 
} 
::-webkit-scrollbar-thumb {
    -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3); 
}
</style>
