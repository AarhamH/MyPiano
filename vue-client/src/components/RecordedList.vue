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
          <td>{{ song.title }} </td>
          <td>{{ song.created }}</td>
          <td class="st_column_action">
            <audio
              ref="audioPlayer"
              id="audioPlayer"
              controls
              :src="'https://localhost:7089/api/Audio/audio/' + song.title + '.webm'"             
            ></audio>
          </td>
          <td>             
            <button class="delete_button" @click="deleteSong(song.id, index)">
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
.delete_button  {
  background: transparent;
  border: transparent;
  cursor: pointer;
}

.delete_button img {
  width:25%;
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
