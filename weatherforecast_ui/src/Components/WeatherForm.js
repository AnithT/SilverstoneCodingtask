import React, { useState } from 'react';
import { TextField, Button } from '@mui/material';

const WeatherForm = ({ onSubmit }) => {
  const [location, setLocation] = useState('');
 

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(location);
  };

  return (
    <form onSubmit={handleSubmit}>
    <TextField
      label="Enter location"
      variant="outlined"
      value={location}
      onChange={(e) => setLocation(e.target.value)}
    />
    <Button type="submit" variant="contained" color="primary">
      Get Weather
    </Button>
  </form>
  );
};

export default WeatherForm;