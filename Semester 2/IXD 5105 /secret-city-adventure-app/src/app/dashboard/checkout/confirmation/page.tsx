import ButtonLarge from '@/component/button/ButtonLarge'
import Image from 'next/image'
import React from 'react'

export default function ComfirmationPage() {
  return (
    <main className='p-4'>
    <div className='flex flex-col gap-4 text-center my-10'>
        <div className='flex justify-center'>
       <Image src="/img/games/confirmation.png" alt='Confirmation' height={500} width={300}/>

        </div>
       <h1 className='text-2xl text-gray-800 font-bold' >Booking Confirmed!</h1>
       <p className='font-medium'>Your adventure awaits </p>
       <p>Adventure booked! Your tickers are no their way to</p>
       <a href="" className='text-sky-800 font-medium'>johndoe@gmail.com</a>
    </div>
    <div>
        <ButtonLarge text="Return to Home Screen" link="/dashboard"/>
    </div>
    </main>
  )
}
