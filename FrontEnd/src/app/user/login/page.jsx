'use client';
import { Box, Button, TextField } from '@mui/material';
import React from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import { getCookie, setCookie } from 'cookies-next';
export default function IdentifyPage() {
  const [password, setPassword] = React.useState('');
  const router = useRouter();
  return (
    <Box component='form'>
      <TextField onChange={(event) => setPassword(event.target.value)} value={password} label='Password' />
      <Button
        onClick={async () => {
          const jwt = await axios.post(
            `${process.env.NEXT_PUBLIC_API_URI}/authorize`,
            {},
            {
              headers: {
                Authorization: `Basic ${btoa(getCookie('email'))}:${btoa(password)}`,
              },
            },
          );
          if (jwt.status === 200) {
            setCookie('jwt', jwt.data);
          }
          router.push('/');
        }}
      >
        Login
      </Button>
    </Box>
  );
}
