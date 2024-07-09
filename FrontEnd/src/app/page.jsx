'use client';
import React from 'react';
import useSWR from 'swr';
import axios from 'axios';
import { Box, Typography } from '@mui/material';
export default function Home() {
  const { data } = useSWR('/weather', async () => {
    const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URI}/weatherforecast`);
    return response.json();
  });
  console.log(data);
  return (
    <Box component='main'>
      <Typography variant='h1'>Hello, World!</Typography>
    </Box>
  );
}
