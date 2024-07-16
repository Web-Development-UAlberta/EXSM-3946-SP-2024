import { createRequire } from 'module';
const require = createRequire(import.meta.url);
const withBundleAnalyzer = require('@next/bundle-analyzer')({
  enabled: true,
});

const nextConfig = {
  env: {
    NEXT_PUBLIC_APP_URI: process.env.APP_URI,
    NEXT_PUBLIC_API_URI: process.env.API_URI,
    NEXT_PUBLIC_COOKIE_DOMAIN: (() => {
      const domain = ((process.env.APP_URI ?? process.env.NEXT_PUBLIC_APP_URI ?? '').split('://')[1] ?? '').split(':')[0];
      const ipPattern = /^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$/;
      return ipPattern.test(domain) ? domain : domain.split('.').reverse().slice(0, 2).reverse().join('.');
    })(),
  },
};

export default process.env.NEXT_ANALYZE === 'true' ? withBundleAnalyzer(nextConfig) : nextConfig;
