import { useDispatch, useSelector } from "react-redux"
import { CounterState, decrement, increment } from "./counterReducer"
import { Button, ButtonGroup, Typography } from "@mui/material";

export default function ContactPage() {
  const data = useSelector((state: CounterState) => state.data);
  const dispatch = useDispatch();

  return (
    <>
      <Typography variant="h2">
        Contact page
      </Typography>
      <Typography variant="body1" >
        The data is: {data}
      </Typography>
      <ButtonGroup>
        <Button onClick={() => dispatch(decrement())} color='error'>Decrement</Button>
        <Button onClick={() => dispatch(increment())} color='secondary'>Increment</Button>
        <Button onClick={() => dispatch(increment(5))} color='primary'>Increment by 5</Button>
      </ButtonGroup>
    </>
  )
}