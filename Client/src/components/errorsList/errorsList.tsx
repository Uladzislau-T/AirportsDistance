import { FC } from 'react';
import { FieldErrorsImpl } from 'react-hook-form';

interface ErrorsListProps {
  errors: Partial<FieldErrorsImpl<any>>;
}

export const ErrorsList: FC<ErrorsListProps> = ({ errors }) => {
  return (
    <ul className="list-group list-group-numbered pl-1">
      {(Object.keys(errors) as (keyof typeof errors)[]).map((field) => (
        <li
          key={`error-${String(field)}`}
          className="list-group-item text-danger"
        >
          {errors[String(field)]!.message as string}
        </li>
      ))}
    </ul>
  );
};
