<template>
    <div class="signup-page">
  <div class="signup-container" style="margin-top: 79px;background-color: aliceblue;">
    <img class="logo" src="../assets/food_logo.png" alt="Restaurant Logo">
    <h1>Sign Up</h1>
    <div class="register">
      <div>
        <label>Name</label>
        <input type="text" v-model="name" placeholder="Enter the Name" required>
      </div>
      <div>
        <label>Email</label>
        <input type="email" v-model="email" placeholder="Enter Email" required>
      </div>
      <div>
        <label>Password</label>
        <input type="password" v-model="password" placeholder="Enter Password" required>
      </div>
      <button v-on:click="signUp">Sign Up</button>
      <p>
      <router-link to="/login">Login</router-link>
      </p>
    </div>
  </div>
</div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'SignUp',
  data() {
    return {
      name: '',
      email: '',
      password: ''
    }
  },
  methods: {
   async signUp() {
     let result = await axios.post("http://localhost:5165/api/Home",{
        email: this.email,
        password:this.password,
        name:this.name
     });
     console.warn(result);
     if(result.status == 200)
     {
      localStorage.setItem("user-info",JSON.stringify(result.data))
           this.$router.push({name:'LoginPage'})
    }

 
     
    }
  }

}
</script>


<style>
.signup-page {
  background: url('../assets/background_image.jpg') no-repeat center center fixed;
  background-size: cover;
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>