import urlHelper from "../helpers/urlHelper";
export class BaseService {
    private domainApi: string;
    constructor(domainKey: string) {
        this.domainApi = urlHelper.getApiUrl(domainKey);
    }
    public resolveUrl(url: string): string {
        return this.domainApi + url;
    }
}