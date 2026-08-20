import ButtonLarge from "@/component/button/ButtonLarge";
import Image from "next/image";

export default function LoginPages() {
  return (
    <section className="flex flex-col bg-[url('/img/signup.png')]">
      {/* <div className="bg-[url('/img/login-back.png')] bg-cover bg-center bg-no-repeat h-40 w-full flex justify-center items-center py-10"> */}
      <div className="h-40 py-10 flex justify-center items-center">
        <Image
          src="/img/logo.png"
          width={160}
          height={80}
          alt="Picture of the author"
        />
      </div>
      <div className="">
        <div className="bg-gray-200 rounded-t-4xl p-10 flex flex-col">
          <h1 className="text-2xl text-center">Sign Up</h1>
          <div className="flex flex-col gap-6 my-4">
            <div className="flex flex-col gap-2">
              <label htmlFor="email">Full Name</label>
              <input
                type="text"
                className="bg-white border border-gray-300 rounded-2xl py-1 px-2"
              />
            </div>
            <div className="flex flex-col gap-2">
              <label htmlFor="email">Enter your email ID</label>
              <input
                type="email"
                className="bg-white border border-gray-300 rounded-2xl py-1 px-2"
              />
            </div>
            <div className="flex flex-col gap-2">
              <label htmlFor="password">Create Passsword</label>
              <input
                type="password"
                className="bg-white border border-gray-300 rounded-2xl py-1 px-2"
              />
            </div>
            <div className="flex flex-col gap-2">
              <label htmlFor="phone_no">Phone no</label>
              <input
                type="text"
                className="bg-white border border-gray-300 rounded-2xl py-1 px-2"
              />
            </div>
          </div>
          <div className="flex flex-col gap-4">
            <ButtonLarge text="Create Profile" link="/" />
            <button className="rounded-3xl border border-gray-300 bg-gray-100 text-gray-800 w-full py-2 px-2">
              <a href="" className="flex gap-2 justify-center items-center">
                <span>
                  <Image
                    src="/img/google.png"
                    width={20}
                    height={20}
                    alt="Picture of the author"
                  />
                </span>
                Continue with Google
              </a>
            </button>
            {/* <p className="text-center text-sm">
              Don't have an account?{" "}
              <a href="/login" className="text-blue-900 font-medium">
                Sign up
              </a>
            </p> */}
          </div>
        </div>
      </div>
    </section>
  );
}
