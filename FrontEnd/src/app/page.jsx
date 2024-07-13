'use client';
import React from 'react';
import useSWR from 'swr';
import axios from 'axios';
import { Box, Button, Typography } from '@mui/material';
import EditDialog from 'jrgcomponents/EditDialog';
import { DataGrid } from '@mui/x-data-grid';
export default function Home() {
  const { data: rows } = useSWR(
    '/posts',
    async () => {
      const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URI}/api/Post`);
      return response.data;
    },
    {
      fallbackData: [],
    },
  );
  const columns = [
    { field: 'id', headerName: 'ID', width: 90 },
    { field: 'title', headerName: 'Title', width: 150 },
    { field: 'content', headerName: 'Content', width: 150 },
    { field: 'createdAt', headerName: 'CreatedAt', width: 150 },
  ];
  return (
    <Box component='main'>
      <DataGrid rows={rows} columns={columns} />
    </Box>
  );
}
