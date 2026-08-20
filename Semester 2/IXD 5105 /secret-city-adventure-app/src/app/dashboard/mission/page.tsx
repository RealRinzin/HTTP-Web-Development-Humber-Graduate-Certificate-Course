'use client';

import { useRouter } from 'next/navigation';
import { Scanner, IDetectedBarcode } from '@yudiel/react-qr-scanner';

export default function Mission() {
  const router = useRouter();

  const handleScan = (detectedCodes: IDetectedBarcode[]) => {
    const value = detectedCodes[0]?.rawValue;
    if (value) router.push('/dashboard/mission/mission-to-final');
  };

  return (
    <Scanner
      onScan={handleScan}
      onError={(error) => console.error(error)}
    />
  );
}
