<template>
    <main class="st_viewport">
        <div class="st_wrap_table" data-table_id="0">
            <header class="st_table_header">
            <h2>Table header one</h2>
            <div class="st_row">
                <div class="st_column _rank">Rank</div>
                <div class="st_column _name">Name</div>
                <div class="st_column _surname">Surname</div>
                <div class="st_column _year">Year</div>
                <div class="st_column _section">Section</div>
            </div>
            </header>
            <div class="st_table">
            <div class="st_row">
                <div class="st_column _rank">0</div>
                <div class="st_column _name">John</div>
                <div class="st_column _surname">Doe</div>
                <div class="st_column _year">1973</div>
                <div class="st_column _section">Germany</div>
            </div>
            </div>
            
        </div>
        </main>
</template>

<style lang="scss">
h1{
  font-weight: 400;
}
a{
  color: inherit;
}
p{
  margin-top: .7em;
}
.warning{
  color: rgb(62,148,236);
}
.st_viewport{
  max-height: 500px;
  overflow: auto;
}

[data-table_id="1"]{
  background-color: rgb(255,115,0);
}
[data-table_id="2"]{
  background-color: rgb(61,53,39);
  color: rgb(220,220,220);
}
[data-table_id="3"]{
  background-color: rgba(168,189,4, .8);
}

._rank{
  min-width: 80px;
}
._id{
  min-width: 60px;
}
._name{
  min-width: 130px;
}
._surname{
  min-width: 130px;
}
._year{
  min-width: 80px;
}
._section{
  min-width: 130px;
}

pre{
  overflow: auto;
}

/** Sticky table styles **/
.st_viewport{
  background-color: rgb(62,148,236);
  color: rgb(27,30,36);
  margin: 20px 0;
}
/* ##   header */
.st_table_header{
  position: -webkit-sticky;
  position: sticky;
  top: 0px;
  z-index: 1;
  background-color: rgb(27,30,36);
  color: rgb(220,220,220);
}
.st_table_header h2{
  font-weight: 400;
  margin: 0 20px;
  padding: 20px 0 0;
}
.st_table_header .st_row{
  color: rgba(220,220,220, .7);  
}
/* ##  table */
.st_table{
  display: -webkit-box;
  display: -webkit-flex;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -webkit-flex-direction: column;
      -ms-flex-direction: column;
          flex-direction: column;
}
/* #   row */
.st_row{
  display: -webkit-box;
  display: -webkit-flex;
  display: -ms-flexbox;
  display: flex;
  margin: 0;
}
.st_table .st_row:nth-child(even){
  background-color: rgba(0,0,0, .1)
}
/* #   column */
.st_column{
  padding: 10px 20px;
}
</style>