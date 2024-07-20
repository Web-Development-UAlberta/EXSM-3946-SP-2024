import { NextResponse } from 'next/server';
import axios from 'axios';
export default async function Middleware(request) {
  if (request.nextUrl.pathname.startsWith('/_next/') || request.nextUrl.pathname.startsWith('/api/') || request.nextUrl.pathname === '/favicon.ico') {
    return NextResponse.next();
  }
  const jwt = request.cookies.get('jwt')?.value;
  console.log('JWT: ', jwt);
  if (!request.nextUrl.pathname.startsWith('/user')) {
    if (jwt) {
      console.log('JWT Present, Validating...');
      const validateJWTResponse = await axios.get(`${process.env.API_URI}/user`, {
        headers: {
          Authorization: `Bearer ${jwt}`,
        },
        validateStatus: () => true,
      });
      if (validateJWTResponse.status === 200) {
        return NextResponse.next();
      } else {
        return NextResponse.redirect(new URL(`${process.env.APP_URI}/user`), {
          headers: {
            'Set-Cookie': `jwt=; domain=${process.env.NEXT_PUBLIC_COOKIE_DOMAIN}`,
          },
        });
      }
    } else {
      return NextResponse.redirect(new URL(`${process.env.APP_URI}/user`), {
        headers: {
          'Set-Cookie': `jwt=; domain=${process.env.NEXT_PUBLIC_COOKIE_DOMAIN}`,
        },
      });
    }
  }
  return NextResponse.next();
}
