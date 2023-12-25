import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"
import { baseUrl } from "../../../core/api/baseUrl"

export interface getDistanceParams{
  iata1: string,
  iata2: string,
  units: string
}

export interface DistanceResponse{
  airportFirst: string,
  airportSecond: string,
  distance: number,
  units: string
}

export interface ErrorResponse{
  statusCode: string,
  errors: string[]
}

export const distanceAPI = createApi({
  reducerPath: "distanceAPI",
  baseQuery: fetchBaseQuery({baseUrl}),
  tagTypes: ['Post', 'Distance'],
  endpoints: (build) => ({

    getDistance: build.query<DistanceResponse | ErrorResponse, getDistanceParams>({
      query: ({iata1, iata2, units}) => ({
        url: '/distance?',
        params:{          
          iata1: iata1,
          iata2: iata2,
          units: units
        }
      }),            
      // providesTags: result => ['Distance']
    })
  })
})

export const {
  useLazyGetDistanceQuery ,
} = distanceAPI;