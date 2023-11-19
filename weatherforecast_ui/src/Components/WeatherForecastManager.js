import React, { useState,useEffect  } from 'react';
import WeatherForm from './WeatherForm';
import WeatherList from './WeatherList';
import SearchHistoryList from './SearchHistoryList';
import WeatherForecastService from '../Services/WeatherForecastService';
import { Grid, Paper, Typography } from '@mui/material';

const WeatherForecastManager = () => {
  const [weatherList, setWeatherList] = useState([]);
  const [searchHistory, setSearchHistory] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Fetch the search history data on page load
    const fetchSearchHistory = async () => {
      try {
        const historyData = await WeatherForecastService.getWeatherInfoByUser(1);
        const locationNames = historyData.map(item => item.locationName);
        setSearchHistory(locationNames);
      } catch (error) {
        setError(error.message);
      }
    };

    fetchSearchHistory();
  }, []); 

  const getWeatherInfo = async (location) => {
    try {
      const data = await WeatherForecastService.getWeatherInfo(location);
      setSearchHistory((prevHistory) => [...prevHistory, data.locationName]);
      saveWeatherInfo(data);
      setWeatherList([data]);
      setError(null);
    } catch (error) {
      setError(error.message);
    }
  };

  const saveWeatherInfo = (data) => {
       WeatherForecastService.saveWeatherDetails({
        locationName: data.locationName,
        currentTemperature: data.current_temperature,
        humidity: data.humidity,
        maximumTemperature: data.maximum_temperature,
        minimumTemperature: data.minimum_temperature,
        Name: 'Anith',
        UserId: 1
      });
  };
  const handleLocationClick = async (location) => {
    try {
      const data = await WeatherForecastService.getWeatherInfo(location[0].locationName);
      setWeatherList([data]);
    } catch (error) {
      console.error('Error fetching weather data:', error);
      // Handle error, show a message to the user, etc.
    }
  };


  return (
    <Grid container spacing={3}>
    <Grid item xs={12}>
      <Typography variant="h4">Weather Forecast App</Typography>
    </Grid>
    <Grid item xs={12} sm={6}>
    {error && <Typography variant="body2" color="error">{error}</Typography>}
      <Paper elevation={3} style={{ padding: '20px' }}>
        <WeatherForm onSubmit={getWeatherInfo} />
        <WeatherList weatherList={weatherList} />
      </Paper>
    </Grid>
    <Grid item xs={12} sm={6}>
      <Paper elevation={3} style={{ padding: '20px' }}>
        <SearchHistoryList searchHistory={searchHistory} onLocationClick={handleLocationClick} />
      </Paper>
    </Grid>
  </Grid>
  );
};

export default WeatherForecastManager;