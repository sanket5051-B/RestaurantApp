<template>
  <div class="background-container">
  <div class="update-container">
    <h2>Update Restaurant</h2>
    <form @submit.prevent="updateRestaurant">
      <div class="form-group">
        <label for="name">Name:</label>
        <input v-model="restaurant.name" type="text" id="name" required />
      </div>
      <div class="form-group">
        <label for="contact">Contact:</label>
        <input v-model="restaurant.contact" type="text" id="contact" required />
      </div>
      <div class="form-group">
        <label for="address">Address:</label>
        <input v-model="restaurant.address" type="text" id="address" required />
      </div>
      <button type="submit" class="btn btn-primary">Update</button>
    </form>
  </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'UpdatePage',
  data() {
    return {
      restaurant: {
        name: '',
        contact: '',
        address: ''
      }
    };
  },
  async mounted() {
    const id = this.$route.params.id;
    try {
      let result = await axios.get(`http://localhost:5165/api/Home/${id}`);
      this.restaurant = result.data;
    } catch (error) {
      console.error('Failed to load restaurant:', error);
    }
  },
  methods: {
    async updateRestaurant() {
      const id = this.$route.params.id;
      try {
        await axios.put(`http://localhost:5165/api/Home/${id}`, this.restaurant);
        this.$router.push({ name: 'HomePage' });
      } catch (error) {
        console.error('Failed to update restaurant:', error);
      }
    }
  }
}
</script>

<style>
.update-container {
  background-color: rgba(255, 255, 255, 0.9);
  max-width: 50%;
  /* Adjust the max-width as needed */
  margin-top: 80px;
  padding: 20px;
  /* Add some padding inside the container */
  border: 1px solid #ddd;
  /* Light gray border */
  border-radius: 8px;
  /* Rounded corners */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  /* Optional: Add shadow for depth */
  margin-left: auto;
  margin-right: auto;


}

.background-container
{
background: url('../assets/kitchen.jpg') no-repeat center center fixed;
  background-size: cover;
  min-height: 100vh;
  padding: 20px;
}
.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  margin-bottom: 5px;
  margin-left: -213px;
}

.form-group input {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
}

.btn-primary {
  background-color: #007bff;
  color: white;
  border: none;
  padding: 10px 15px;
  cursor: pointer;
}

.btn-primary:hover {
  background-color: #0056b3;
}
</style>
