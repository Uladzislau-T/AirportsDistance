import { yupResolver } from '@hookform/resolvers/yup';
import { FC, useState } from 'react';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import * as yup from 'yup';
import { ErrorsList } from '../../../components/errorsList/errorsList';
import { DistanceResponse, useLazyGetDistanceQuery } from '../api/repository';
import "./distancePage.css";

interface DistancePageProps {}

interface DistanceFormValues {
  iata1: string;
  iata2: string;
  units: string; 
}

const regExp = /^[A-Z]{3}$/

const validationSchema = yup.object({  
  iata1: yup.string().min(3).max(3).uppercase().required().matches(regExp, "Iata code must contain only 3 uppercase letters of latin alphabet"),  
  iata2: yup.string().min(3).max(3).uppercase().required().matches(regExp, "Iata code must contain only 3 uppercase letters of latin alphabet"),
  units: yup.string().required(), 
});

export const DistancePage: FC<DistancePageProps> = ({}) => {
  const [distanceData, setDistanceData] = useState<DistanceResponse>({
      airportFirst:"",
      airportSecond:"",
      distance:0,
      units:"Miles"
    }
  );
  const [ triggerGetDistance, {data, isLoading} ] = useLazyGetDistanceQuery(
    // {
    // sortingItem: sorting,
    // page: page,
    // limit: limit,
    // }
  ); 

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<DistanceFormValues>({
    defaultValues: {      
      iata1: "",
      iata2: "",     
      units: "",
    },
    resolver: yupResolver(validationSchema),
  });

  const onSubmit = async (values: DistanceFormValues) => {
    try {
      
      let temp = await triggerGetDistance({iata1:values.iata1, iata2:values.iata2, units:values.units}).unwrap();

      if("units" in temp){
        setDistanceData(temp);
      }
      else{
        temp.errors.map(error => toast.error(error));
      }   
    } catch (e) {
      toast.error("Something went wrong. Please, check your data and try again later");
    }
  };

  return (
    <div style={{marginLeft:"50px", marginTop:"70px"}}>
      <p style={{width:"50%"}}>
      To calculate airport distance, enter IATA codes of the two airports between which you need to find the distance in the text boxs below, choose distance units and click 'Calculate' button. The result on the right will show you the the air travel distance between the airports.
      </p>
      <div className='distancePage-form-container'>
        <form className="d-flex flex-column gap-4" onSubmit={handleSubmit(onSubmit)} style={{width:"360px"}}>
          <ErrorsList errors={errors} />
          <input placeholder="First IATA Code" {...register('iata1')} className='form-control' />

          <input placeholder="Second IATA Code" {...register('iata2')} className='form-control' />
          
          <div style={{}}>
            <label htmlFor="units">Choose distance units:</label>
            <select id='units' defaultValue="Miles" className="form-select distancePage-form-select"  {...register('units')}>   
              <option value="Miles">Miles</option>
              <option value="Kilometres">Kilometres</option>
              <option value="Metres">Metres</option>
            </select>
          </div>

          {/* <input
            placeholder="units"
            {...register('units')}
          /> */}
          <div className="flex justify-end">
            <button type="submit" className="btn btn-primary" >
              Calculate
            </button>
          </div>
        </form>
        {
          data && "units" in data &&
            <div style={{marginTop:"30px", marginLeft:"2rem"}}>
              The distance from {distanceData.airportFirst} airport to {distanceData.airportSecond} airport is <strong style={{color:"red"}}>{distanceData.distance}</strong> {distanceData.units}
            </div>
        }
      </div>
    </div>
  );
};
