import type { Metadata } from 'next';
import './globals.css';

export const metadata: Metadata = {
  title: 'Movable Rotation Center (Pivot) – Three.js + R3F',
  description: 'Interactive 3D pivot rotation demo built with React Three Fiber',
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  );
}
