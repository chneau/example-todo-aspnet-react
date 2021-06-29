import React from "react";
import styled from "styled-components";
import logo from "./logo.svg";

const Logo = styled.img`
  height: 40vmin;
  pointer-events: none;

  @media (prefers-reduced-motion: no-preference) {
    animation: App-logo-spin infinite 20s linear;
  }

  @keyframes App-logo-spin {
    from {
      transform: rotate(0deg);
    }
    to {
      transform: rotate(360deg);
    }
  }
`;

const Header = styled.header`
  background-color: #282c34;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  font-size: calc(10px + 2vmin);
  color: white;
`;

const HomeLink = styled.a`
  color: #61dafb;
`;

export const HomePage = () => (
  <div>
    <Header>
      <Logo src={logo} alt="logo" />
      <p>
        Edit <code>src/App.tsx</code> and save to reload.
      </p>
      <HomeLink href="https://reactjs.org" target="_blank" rel="noopener noreferrer">
        Learn React
      </HomeLink>
    </Header>
  </div>
);
