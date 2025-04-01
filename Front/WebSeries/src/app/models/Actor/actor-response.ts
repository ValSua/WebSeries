import { GetActorDto } from "./getActorDto";


export interface ActorResponse {
  isSuccess: boolean;
  result: GetActorDto[];
  message: string;
}