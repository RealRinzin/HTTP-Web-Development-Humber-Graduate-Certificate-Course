/** @type {import('next').NextConfig} */
const nextConfig = {
  // Needed for @react-three/fiber + drei in some environments
  transpilePackages: ['three', '@react-three/fiber', '@react-three/drei'],
};

module.exports = nextConfig;
