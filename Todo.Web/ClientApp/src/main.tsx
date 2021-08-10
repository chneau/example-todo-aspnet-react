import { ApolloClient, ApolloProvider, from, HttpLink, InMemoryCache } from "@apollo/client";
import { onError } from "@apollo/client/link/error";
import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { Header } from "./components/Header";
import "./index.css";
import { GraphQLPage } from "./pages/GraphQLPage";
import { HomePage } from "./pages/HomePage";
import { ProfilerPage } from "./pages/ProfilerPage";
import { TestingPage } from "./pages/TestingPage";

// Log any GraphQL errors or network error that occurred
const errorLink = onError(({ graphQLErrors, networkError }) => {
  if (graphQLErrors) graphQLErrors.map(({ message, locations, path }) => console.log(`[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`));
  if (networkError) console.log(`[Network error]: ${networkError}`);
});

const httpLink = new HttpLink({
  uri: import.meta.env.VITE_GRAPHQL_URL ?? "https://localhost:5001/graphql",
});

const client = new ApolloClient({
  cache: new InMemoryCache(),
  link: from([errorLink, httpLink]),
});

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Header />
      <ApolloProvider client={client}>
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route exact path="/testing" component={TestingPage} />
          <Route exact path="/iframe/graphql" component={GraphQLPage} />
          <Route exact path="/iframe/profiler" component={ProfilerPage} />
        </Switch>
      </ApolloProvider>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);
