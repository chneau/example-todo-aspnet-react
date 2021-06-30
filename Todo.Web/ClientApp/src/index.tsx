import { ApolloClient, ApolloProvider, from, HttpLink, InMemoryCache } from "@apollo/client";
import { onError } from "@apollo/client/link/error";
import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { Header } from "./components/Header";
import { HomePage } from "./pages/HomePage";
import { TestingPage } from "./pages/TestingPage";
import { reportWebVitals } from "./reportWebVitals";

// Log any GraphQL errors or network error that occurred
const errorLink = onError(({ graphQLErrors, networkError }) => {
  if (graphQLErrors) graphQLErrors.map(({ message, locations, path }) => console.log(`[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`));
  if (networkError) console.log(`[Network error]: ${networkError}`);
});

const client = new ApolloClient({
  cache: new InMemoryCache(),
  link: from([errorLink, new HttpLink({ uri: "/graphql" })]),
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
