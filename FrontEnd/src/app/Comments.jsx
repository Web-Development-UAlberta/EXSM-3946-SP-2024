'use client';
import React from 'react';
import useSWR from 'swr';
import axios from 'axios';
import { List, ListItem, Typography } from '@mui/material';

export default function Comments({ postID }) {
  const { data: comments } = useSWR(
    `/posts/{${postID}}/comments`,
    async () => {
      const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URI}/api/Comment/bypost/${postID}`);
      return response.data;
    },
    {
      fallbackData: [],
    },
  );
  return (
    <List>
      {comments.map((comment) => (
        <ListItem key={comment.id} sx={{ flexDirection: 'column' }}>
          <Typography variant='body1' component='p'>
            {comment.text}
          </Typography>
          <Typography variant='caption' component='span'>
            {comment.createdAt} by {comment.author}
          </Typography>
        </ListItem>
      ))}
    </List>
  );
}
