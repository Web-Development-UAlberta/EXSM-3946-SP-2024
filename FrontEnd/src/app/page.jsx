'use client';
import React from 'react';
import useSWR, { mutate } from 'swr';
import axios from 'axios';
import { Box, IconButton } from '@mui/material';
import { Comment, Edit } from '@mui/icons-material';
import { DataGrid } from '@mui/x-data-grid';
import EditDialog from 'jrgcomponents/EditDialog';
import Dialog from 'jrgcomponents/Dialog';
import Comments from './Comments';

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
    {
      field: 'actions',
      headerName: 'Actions',
      width: 150,
      renderCell: (cellValues) => {
        return (
          <>
            <Dialog
              title={`Comments of Post #${cellValues.row.id}`}
              content={<Comments postID={cellValues.row.id} />}
              ButtonComponent={IconButton}
              ButtonProps={{ children: <Comment /> }}
            />

            <EditDialog
              toUpdate={cellValues.row}
              excludeFields={['id', 'createdAt']}
              ButtonComponent={IconButton}
              ButtonProps={{ children: <Edit /> }}
              onConfirm={async (data) => {
                console.log('New Data:', data);
                await axios.put(`${process.env.NEXT_PUBLIC_API_URI}/api/Post/${cellValues.row.id}`, { ...cellValues.row, ...data });
                mutate('/posts');
              }}
            />
          </>
        );
      },
    },
  ];
  return (
    <Box component='main'>
      <DataGrid rows={rows} columns={columns} />
    </Box>
  );
}
