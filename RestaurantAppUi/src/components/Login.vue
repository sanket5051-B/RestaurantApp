<template>
  <div class="login-page">
    <div class="signup-container">
      <img class="logo" src="../assets/food_logo.png" alt="Restaurant Logo">
      <h1>Login</h1>
      <div class="login">
        <div>
          <label>Email</label>
          <input type="email" v-model="email" placeholder="Enter Email" required>
        </div>
        <div>
          <label>Password</label>
          <input type="password" v-model="password" placeholder="Enter Password" required>
        </div>
        <button @click="login">Login</button>
        <p>
          <router-link to="/sign-up">Sign Up</router-link>
        </p>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'LoginPage',
  data() {
    return {
      email: '',
      password: ''
    };
  },
  methods: {
    async login() {
      try {
        let result = await axios.get(
          `http://localhost:5165/api/Home?email=${this.email}&password=${this.password}`
        );

        if (result.status === 200 && result.data.length > 0) {
          localStorage.setItem("user-info", JSON.stringify(result.data[0]));
          this.$router.push({ name: "HomePage" });
        }
      } catch (error) {
        console.error('Login failed:', error);
      }
    }
  },
  mounted() {
    let user = localStorage.getItem('user-info');
    if (user) {
      this.$router.push({ name: "HomePage" });
    }
  }
};
</script>

<style>
/* Add a background image */
.login-page {
  background: url('../assets/background_image.jpg') no-repeat center center fixed;
  background-size: cover;
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
}

.signup-container {
  background-color: rgba(255, 255, 255, 0.9); /* Optional: Semi-transparent background for readability */
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 100%;
}

.logo {
  display: block;
  margin: 0 auto;
  max-width: 100px;
}

.login {
  margin-top: 20px;
}

.login label {
  display: block;
  margin-bottom: 5px;
}

.login input {
  width: 100%;
  padding: 8px;
  margin-bottom: 10px;
  border: 1px solid #ddd;
  border-radius: 4px;
}

.login button {
  width: 100%;
  padding: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.login button:hover {
  background-color: #0056b3;
}

p {
  text-align: center;
  margin-top: 10px;
}

a {
  color: #007bff;
}
</style>
