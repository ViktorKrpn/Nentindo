import { Company } from "../companies";
import { User } from "../users";

export type CreateArticleRequestBody = {
    title: string;
    summary: string;
    description: string
}

export type Article = {
    id: number
    title: string
    summary: string
    description: string
    createdAt: Date
    createdByUserId: number
    createdByUser: User
    companyId: number
    company: Company
} 