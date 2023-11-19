import React from 'react';
import WeatherCard from './WeatherCard';
import WeatherForecastService from '../Services/WeatherForecastService';
import { Typography, List, ListItem, Paper } from '@mui/material';

const SearchHistoryList = ({ searchHistory,onLocationClick  }) => {
    const handleLocationClick = async (location) => {
        try {
          const data = await WeatherForecastService.getWeatherInfo(location);
          onLocationClick([data]);
        } catch (error) {
          console.error('Error fetching weather data:', error);
          // Handle error, show a message to the user, etc.
        }
      };
  return (
   
      <div>
      <Typography variant="h5">Search History</Typography>
      <Paper elevation={3} style={{ maxHeight: '300px', overflowY: 'auto', padding: '10px' }}>
        <List>
          {searchHistory.map((location, index) => (
            <ListItem key={index} button onClick={() =>handleLocationClick(location)}>
              <Typography variant="body1">{location}</Typography>
            </ListItem>
          ))}
        </List>
      </Paper>
    </div>
  );
};

export default SearchHistoryList;