import React from "react";
import { Nav, Navbar } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import styled from "styled-components";

const HeaderNavbar = styled(Navbar)`
  user-select: none;
`;

export const Header = () => (
  <HeaderNavbar bg="light" expand="lg">
    <Navbar.Brand>Todo App</Navbar.Brand>
    <Navbar.Toggle aria-controls="basic-navbar-nav" />
    <Navbar.Collapse id="basic-navbar-nav">
      <Nav className="mr-auto">
        <NavLink exact to="/" className="nav-link" activeClassName="active">
          Home
        </NavLink>
        <NavLink to="/service" className="nav-link" activeClassName="active">
          Service
        </NavLink>
        <NavLink to="/about" className="nav-link" activeClassName="active">
          About
        </NavLink>
        <NavLink to="/graphql" target="_blank" className="nav-link" activeClassName="active">
          GraphQL
        </NavLink>
      </Nav>
    </Navbar.Collapse>
  </HeaderNavbar>
);
