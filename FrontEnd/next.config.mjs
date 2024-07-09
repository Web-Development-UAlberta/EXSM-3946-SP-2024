import { createRequire } from 'module';
const require = createRequire(import.meta.url);
const withBundleAnalyzer = require('@next/bundle-analyzer')({
  enabled: true,
});

const nextConfig = {
  env: {
    NEXT_PUBLIC_APP_URI: process.env.APP_URI,
    NEXT_PUBLIC_API_URI: process.env.API_URI,
  },
};

export default process.env.NEXT_ANALYZE === 'true' ? withBundleAnalyzer(nextConfig) : nextConfig;
