import 'jrgcomponents/Style/Global';
import AppWrapper from 'jrgcomponents/AppWrapper/Wrapper';
import React from 'react';

export const metadata = {
  title: 'UAlberta FullStack',
  description: 'An application created by a student of the University of Alberta Fullstack Web Application Development program.',
};

export default function RootLayout({ children }) {
  return (
    <html lang='en'>
      <body>
        <AppWrapper
          keepThemeToggles
          header={{
            components: {
              center: 'UAlberta FullStack',
              right: 'test',
            },
          }}
          footer={{
            components: {
              center: 'Test',
            },
          }}
        >
          {children}
        </AppWrapper>
      </body>
    </html>
  );
}
