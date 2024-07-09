'use client';
import 'jrgcomponents/Style/Global';
import ThemedAppWrapper from 'jrgcomponents/AppWrapper/Wrapper/Themed';
import React from 'react';

/*
export const metadata = {
  title: 'UAlberta FullStack',
  description: 'An application created by a student of the University of Alberta Fullstack Web Application Development program.',
};
*/

export default function RootLayout({ children }) {
  return (
    <html lang='en'>
      <body>
        <ThemedAppWrapper
          appWrapperConfig={{
            keepThemeToggles: true,
            header: {
              components: {
                center: 'UAlberta FullStack',
                right: 'test',
              },
            },
            footer: {
              components: {
                center: 'Test',
              },
            },
          }}
        >
          {children}
        </ThemedAppWrapper>
      </body>
    </html>
  );
}
