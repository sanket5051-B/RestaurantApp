<template>
  <Header />
  <div class="background-container">
    <div class="content-container">
      <h3 style="margin-top: 20px"> {{ name }}  Here's Your List of Restaurants</h3>
      <div class="table-container">
        <table class="table table-striped table-hover table-bordered">
          <thead>
            <tr>
              <th>Name</th>
              <th>Contact</th>
              <th>Address</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in restaurants" :key="item.id">
              <td>{{ item.name }}</td>
              <td>{{ item.contact }}</td>
              <td>{{ item.address }}</td>
              <td>
                <div class="row">
                  <div class="col">
                    <button @click="navigateToUpdate(item.id)" class="btn btn-warning">Update</button>
                  </div>
                  <div class="col">
                    <button @click="confirmDelete(item.id)" class="btn btn-danger">Delete</button>
                  </div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import Header from './Header.vue';
import axios from 'axios';

export default {
  name: 'HomePage',
  components: {
    Header
  },
  data() {
    return {
      name: '',
      userId: '',
      restaurants: [],
      filteredRestaurants: []
    };
  },
  async mounted() {
    let user = localStorage.getItem('user-info');
    if (!user) {
      this.$router.push({ name: "SignUp" });
      return;
    }
    const userInfo = JSON.parse(user);
    this.name = userInfo.name;
    this.userId = userInfo.id;

    try {
      let result = await axios.get("http://localhost:5165/api/Home");
      this.restaurants = result.data;
      console.log("result.data",result.data);
      this.filterRestaurants();
    } catch (error) {
      console.error('Failed to load restaurants:', error);
    }
  },
  methods: {
    filterRestaurants() {
      this.filteredRestaurants = this.restaurants.filter(r => r.userId === this.userId);
    },
    navigateToUpdate(id) {
      this.$router.push({ name: 'UpdatePage', params: { id } });
    },
    confirmDelete(id) {
      if (confirm('Are you sure you want to delete this item?')) {
        this.deleteRestaurant(id);
      }
    },
    async deleteRestaurant(id) {
      try {
        await axios.delete(`http://localhost:5165/api/Home/${id}`);
        this.restaurants = this.restaurants.filter(item => item.id !== id);
        this.filterRestaurants();
      } catch (error) {
        console.error('Failed to delete restaurant:', error);
      }
    },
    logout() {
      localStorage.removeItem('user-info');
      this.$router.push({ name: "SignUp" });
    }
  }
}
</script>

<style>
/* Background image style for the entire page */
.background-container {
  background: url('../assets/kitchen.jpg') no-repeat center center fixed;
  background-size: cover;
  min-height: 100vh;
  padding: 20px;
  /* Optional: Add some padding around the content */
}

.content-container {
  background-color: rgba(255, 255, 255, 0.9);
  /* Semi-transparent background for readability */
  border-radius: 8px;
  padding: 20px;
  max-width: 1200px;
  margin: 20px auto;
  /* Center the content and set max-width */
}

.table-container {
  margin-top: 20px;
  border: 2px solid black;
  /* Black border around the table container */
}

.table-bordered {
  border: 2px solid black;
  /* Black border for the table */
}

.table th,
.table td {
  border: 1px solid black;
  /* Black border for table cells */
}
</style>
