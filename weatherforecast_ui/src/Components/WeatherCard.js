import React from 'react';
import { Card, CardContent, Typography } from '@mui/material';


const WeatherCard = ({ weather }) => {
  return (
    <Card style={{backgroundColor: '#f0f0f0'}}>
    <CardContent>
      <Typography variant="h6" gutterBottom>
        Weather Information
      </Typography>
      <Typography variant="body1" component="p">
        Current Temperature: {weather.current_temperature}°C
      </Typography>
      <Typography variant="body1" component="p">
        Humidity: {weather.humidity}%
      </Typography>
      <Typography variant="body1" component="p">
        Max Temperature: {weather.maximum_temperature}°C
      </Typography>
      <Typography variant="body1" component="p">
        Min Temperature: {weather.minimum_temperature}°C
      </Typography>
    </CardContent>
  </Card>
  );
};

export default WeatherCard;