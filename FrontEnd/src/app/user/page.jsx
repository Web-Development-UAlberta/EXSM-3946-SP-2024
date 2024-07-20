'use client';
import { Box, Button, TextField } from '@mui/material';
import React from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import { setCookie } from 'cookies-next';
export default function IdentifyPage() {
  const [email, setEmail] = React.useState('');
  const router = useRouter();
  return (
    <Box component='form'>
      <TextField onChange={(event) => setEmail(event.target.value)} value={email} label='Email' />
      <Button
        onClick={async () => {
          try {
            const exists = await axios.get(`${process.env.NEXT_PUBLIC_API_URI}/user/exists?email=${email}`, { validateStatus: (status) => [200, 404].includes(status) });
            console.log(exists);
            setCookie('email', email);
            if (exists.status === 200) {
              router.push('/user/login');
            } else if (exists.status === 404) {
              router.push('/user/register');
            }
          } catch (error) {
            console.error('Error:', error);
          }
        }}
      >
        Continue
      </Button>
    </Box>
  );
}
