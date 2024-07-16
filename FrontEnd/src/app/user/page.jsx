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
          const exists = await axios.get(`${process.env.NEXT_PUBLIC_API_URI}/user/exists?email=${email}`).data;
          setCookie('email', email);
          if (exists) {
            router.push('/user/login');
          } else {
            router.push('/user/register');
          }
        }}
      >
        Continue
      </Button>
    </Box>
  );
}
