<template>
  <Header />
  <div class="background-container">
  <div class="container">
    <h1 class="my-4 text-danger">Add New Restaurant</h1>
    <div class="row">
      <!-- Left column for the image -->
      <div class="col-md-6">
        <img src="../assets/restaurant-service.jpg" alt="Restaurant Image" class="img-fluid" />
      </div>
      <!-- Right column for the form -->
      <div class="col-md-6">
        <form class="add">
          <div class="mb-3">
            <label for="name" class="form-label">Restaurant Name</label>
            <input type="text" id="name" placeholder="Enter the Name" v-model="restaurant.name" required />
          </div>
          <div class="mb-3">
            <label for="address" class="form-label">Contact Address</label>
            <input type="text" id="address" placeholder="Enter the address" v-model="restaurant.address" required />
          </div>
          <div class="mb-3">
            <label for="contact" class="form-label">Contact</label>
            <input type="text" id="contact" placeholder="Enter the contact" v-model="restaurant.contact" required />
          </div>
          <button type="button" @click="addRestaurant" style="width: 115px" class="btn btn-dark">Add New Restaurant</button>
        </form>
      </div>
    </div>
  </div>
  </div>

</template>

<script>
import Header from './Header.vue'
import axios from 'axios';

export default {
  name: 'AddPage',
  components: {
    Header
  },
  data() {
    return {
      restaurant: {
        name: '',
        address: '',
        contact: ''
      },
      userId: ''  // Store user ID here
    };
  },
  methods: {
    async addRestaurant() {
      try {
        const user = JSON.parse(localStorage.getItem('user-info'));
        if (!user) {
          this.$router.push({ name: "SignUp" });
          return;
        }
        this.userId = user.id; // Set the user ID

        const response = await axios.post("http://localhost:5165/api/Home", {
          name: this.restaurant.name,
          address: this.restaurant.address,
          contact: this.restaurant.contact,
          userId: this.userId // Include user ID in the request
          
        });

        if (response.status === 200) {
          this.$router.push({ name: 'HomePage' });
        }
      } catch (error) {
        console.error('Failed to add restaurant:', error);
      }
    }
  },
  mounted() {
    const user = localStorage.getItem('user-info');
    if (!user) {
      this.$router.push({ name: "SignUp" });
    } else {
      const userInfo = JSON.parse(user);
      this.username = userInfo.username; // Assuming user-info is JSON format
    }
  }
}
</script>

<style>
.container {
  background-color: rgba(255, 255, 255, 0.9);
  max-width: 1000px; /* Adjust the max-width as needed */
  margin-top: 20px;
  padding: 20px; /* Add some padding inside the container */
  border: 1px solid #ddd; /* Light gray border */
  border-radius: 8px; /* Rounded corners */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Optional: Add shadow for depth */
}

.img-fluid {
  max-width: 100%;
  height: auto;
}
.background-container
{
background: url('../assets/kitchen.jpg') no-repeat center center fixed;
  background-size: cover;
  min-height: 100vh;
  padding: 20px;
}

.form-label {
  display: block; /* Ensure labels take up full width */
  margin-bottom: 0.5rem; /* Adjust spacing below the label */
  text-align: left; /* Align text to the left */
}

.form-control {
  width: 100%; /* Ensure input fields take up full width */
}
</style>
