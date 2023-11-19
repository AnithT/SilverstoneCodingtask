import axios from 'axios';

const API_BASE_URL = 'https://localhost:7173/api/Weather';

const WeatherForecastService = {
    getWeatherInfo: async (location) => {
      try {
        const response = await axios.get(`${API_BASE_URL}?location=${location}`);
        return response.data;
      } catch (error) {
        if (error.response && error.response.data && error.response.data.message) {
            // If there is a specific error message from the backend, throw it
            throw new Error(error.response.data.message);
          } else {
            // If no specific error message is available, throw a generic error
            throw new Error('Failed to fetch weather data');
          }
      }
    },  
    getWeatherInfoByUser: async (id) => {
        try {
          const response = await axios.get(`${API_BASE_URL}/User?id=${id}`);
          return response.data;
        } catch (error) {
          if (error.response && error.response.data && error.response.data.message) {
              // If there is a specific error message from the backend, throw it
              throw new Error(error.response.data.message);
            } else {
              // If no specific error message is available, throw a generic error
              throw new Error('Failed to fetch weather data');
            }
        }
      },  
    saveWeatherDetails: async (weatherDetails) => {
        try {
          const response = await axios.post(`${API_BASE_URL}`, weatherDetails);
          return response.data;
        } catch (error) {
          console.error('Error saving weather details:', error);
          throw error;
        }
      },
  };

  export default WeatherForecastService;