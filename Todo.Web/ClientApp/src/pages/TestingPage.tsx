import { gql, useMutation, useQuery } from "@apollo/client";
import faker from "faker";
import React from "react";
import { Button, Table } from "react-bootstrap";

interface TodoItem {
  id: string;
  description: string;
}
interface TodoItemData {
  todoItems: TodoItem[];
}

export const TestingPage = () => {
  let { loading, data, refetch } = useQuery<TodoItemData>(gql`
    query GetTodoItemsDescriptions {
      todoItems {
        id
        description
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

  const addRandomTodoAndFetchMore = () => {
    addRandomTodo({ variables: { description: faker.lorem.words(5) } });
    refetch();
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
          </tr>
        </thead>
        <tbody>
          {data?.todoItems.map((x) => (
            <tr key={x.id}>
              <td>{x.id}</td>
              <td>{x.description}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
