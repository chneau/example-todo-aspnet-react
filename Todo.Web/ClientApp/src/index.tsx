import { ApolloClient, ApolloProvider, InMemoryCache } from "@apollo/client";
import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { Header } from "./components/Header";
import { HomePage } from "./pages/HomePage";
import { TestingPage } from "./pages/TestingPage";
import { reportWebVitals } from "./reportWebVitals";

const client = new ApolloClient({
  uri: "/graphql",
  cache: new InMemoryCache(),
});

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Header />
      <ApolloProvider client={client}>
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route exact path="/testing" component={TestingPage} />
        </Switch>
      </ApolloProvider>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals(console.log);
