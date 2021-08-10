import React from "react";
import { Nav, Navbar } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import styled from "styled-components";

const HeaderNavbar = styled(Navbar)`
  user-select: none;
`;

export const Header = () => {
  const commonProps = { className: "nav-link", activeClassName: "active" };
  return (
    <HeaderNavbar bg="light" expand="lg">
      <Navbar.Brand>Todo App</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
          <NavLink exact to="/" {...commonProps}>
            Home
          </NavLink>
          <NavLink to="/testing" {...commonProps}>
            Testing
          </NavLink>
        </Nav>
      </Navbar.Collapse>
    </HeaderNavbar>
  );
};
