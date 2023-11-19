import React from 'react';
import WeatherCard from './WeatherCard';
import { Typography, Grid, Card, CardContent, CardHeader} from '@mui/material';

const WeatherList = ({ weatherList }) => {
  return (

<div>
{weatherList.length === 0 ? (
    
  <Typography variant="body2" color="textSecondary">
    No weather information available.
  </Typography>
) : (
  <Grid container spacing={2}>
    {weatherList.map((weather) => (
      <Grid item key={weather.id} xs={12} sm={6} md={4} lg={6}>
        <Card elevation={3}>
          <CardHeader title={weather.locationName} />
          <CardContent>
          <WeatherCard key={weather.id} weather={weather} />
          </CardContent>
        </Card>
      </Grid>
    ))}
  </Grid>
)}
</div>
);
};

export default WeatherList;