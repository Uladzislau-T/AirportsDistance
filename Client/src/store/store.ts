import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { distanceAPI } from "../modules/Distance/api/repository";

const combineReducer = combineReducers({
  [distanceAPI.reducerPath]: distanceAPI.reducer,
});

export const store = configureStore({
  reducer: combineReducer,
  middleware:(getDefaultMiddleware) => 
    getDefaultMiddleware()
    .concat(distanceAPI.middleware)
        
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch: () => AppDispatch = useDispatch;
export const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector;
export type GetRootState = typeof store.getState;