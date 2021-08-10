import { gql, useMutation, useQuery } from "@apollo/client";
import React from "react";
import { Button, Table } from "react-bootstrap";

interface TodoItem {
  id: string;
  description: string;
  createdAt: Date;
}
interface Node {
  nodes: TodoItem[];
}
interface TodoItemData {
  todoItems: Node;
}

export const TestingPage = () => {
  let { loading, data, refetch } = useQuery<TodoItemData>(gql`
    query GetTodoItemsDescriptions {
      todoItems(order: { createdAt: DESC }, first: 5) {
        nodes {
          id
          description
          createdAt
        }
      }
    }
  `);

  const [addRandomTodo] = useMutation(gql`
    mutation AddTodoItem($description: String!) {
      addTodoItem(input: { description: $description }) {
        todoItem {
          id
        }
      }
    }
  `);

  const addRandomTodoAndFetchMore = async () => {
    await addRandomTodo({ variables: { description: `${Math.random()}` } });
    await refetch();
  };

  if (loading) {
    return <div>Loading ...</div>;
  }

  return (
    <>
      <Button onClick={addRandomTodoAndFetchMore}>Add Random</Button>
      <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th>ID</th>
            <th>Description</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
          {data?.todoItems.nodes.map((x) => (
            <tr key={x.id}>
              <td>{x.id}</td>
              <td>{x.description}</td>
              <td>{x.createdAt}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
