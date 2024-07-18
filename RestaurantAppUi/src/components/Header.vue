<template>
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <div class="container-fluid">
    <a class="navbar-brand text-danger" href="#">Restaurant</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll" aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarScroll">
      <ul class="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll" style="--bs-scroll-height: 100px;">
        <li class="nav-item ">
          <router-link class="nav-link  text-warning"  aria-current="page" to="/">Home</router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link text-warning" to="/add">Add Restaurant</router-link>
        </li>
        
       
          <li class="nav-item">
          <a v-on:click="logout" href="#" class="nav-link text-warning" >Logout</a>
        </li>
      </ul>  
         <div class="d-flex">
   <img class="logo1" src="../assets/vegiis.png">
      </div>
    </div>
  </div>
</nav>
</template>


<script>
export default 
{
    name:'HeaderPage',
    methods:{
        logout()
        {
            localStorage.clear();
            this.$router.push({name:'LoginPage'})
        }
    }
    
}
</script>



<style>
.logo1 {
  display: block;
  margin: 0 auto;
  width: 45px;
}
</style>