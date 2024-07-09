'use client';
import React from 'react';
import useSWR from 'swr';
import axios from 'axios';
import { Box, Button, Typography } from '@mui/material';
import EditDialog from 'jrgcomponents/EditDialog';
export default function Home() {
  const { data } = useSWR('/weather', async () => {
    const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URI}/weatherforecast`);
    return response.data;
  });
  return (
    <Box component='main'>
      <Typography variant='h1'>Hello, World!</Typography>
      {data?.map((forecast) => (
        <Box key={forecast.date}>
          <Typography variant='h2'>{forecast.date}</Typography>
          <Typography variant='body1'>{forecast.temperatureC}°C</Typography>
          <Typography variant='body1'>{forecast.temperatureF}°F</Typography>
          <Typography variant='body1'>{forecast.summary}</Typography>
          <EditDialog
            toUpdate={forecast}
            onConfirm={async (updated) => {
              console.log(updated);
              //await axios.put(`${process.env.NEXT_PUBLIC_API_URI}/weatherforecast`, updated);
            }}
            ButtonComponent={Button}
            ButtonProps={{ children: 'Update', color: 'primary', variant: 'contained' }}
          />
        </Box>
      ))}
    </Box>
  );
}
