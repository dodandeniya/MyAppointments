import React from "react";
import LoginScreen from "../login-screen/LoginScreen";

export interface IHomeProps {}

export default function Home(props: IHomeProps) {
  return (
    <div>
      Home
      <LoginScreen />
    </div>
  );
}
