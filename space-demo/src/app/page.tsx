import dynamic from 'next/dynamic';
import { cookies } from 'next/headers';

// Must be dynamically imported (no SSR) — Three.js needs the browser
const PivotScene = dynamic(() => import('@/components/PivotScene'), { ssr: false });

export default async function Home() {
  const cookieStore = await cookies()
  const theme = cookieStore.get('theme')
  console.log(cookieStore);
  return <PivotScene />;
}
