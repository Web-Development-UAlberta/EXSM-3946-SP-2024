'use client';
import React from 'react';
import useSWR, { mutate } from 'swr';
import axios from 'axios';
import { Box, IconButton, Typography } from '@mui/material';
import { Comment, Edit } from '@mui/icons-material';
import { DataGrid } from '@mui/x-data-grid';
import EditDialog from 'jrgcomponents/EditDialog';
import Dialog from 'jrgcomponents/Dialog';
import Comments from './Comments';

export default function Home() {
  const { data } = useSWR(
    '/joke',
    async () => {
      const response = await axios.get('https://api.chucknorris.io/jokes/random?category=food');
      return response.data;
    },
    {
      fallbackData: [],
    },
  );

  return (
    <Box component='main'>
      <Typography variant='body1'>{data.value}</Typography>
    </Box>
  );
}
