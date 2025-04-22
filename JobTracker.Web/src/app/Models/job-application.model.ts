export interface JobApplicationModel {
    id: number,
    jobTitle: string,
    companyId: number,
    jobLink?: string,
    position?: string,
    jobDescription: string,
    salaryRange?: string,
    jobStatus: number,
    appliedDate: Date,
    rejectionReason?: string
}