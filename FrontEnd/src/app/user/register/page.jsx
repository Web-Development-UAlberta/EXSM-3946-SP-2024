'use client';
import { Box, Button, TextField } from '@mui/material';
import React from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import { getCookie } from 'cookies-next';
export default function RegisterPage() {
  const [password, setPassword] = React.useState('');
  const router = useRouter();
  return (
    <Box component='form'>
      <TextField onChange={(event) => setPassword(event.target.value)} value={password} label='Password' />
      <Button
        onClick={async () => {
          const registration = await axios.post(
            `${process.env.NEXT_PUBLIC_API_URI}/api/register`,
            {},
            {
              headers: {
                Authorization: `Basic ${btoa(getCookie('email') + ':' + password)}`,
              },
            },
          );
          if (registration.status === 201) {
            router.push('/user/login');
          }
        }}
      >
        Register
      </Button>
    </Box>
  );
}
