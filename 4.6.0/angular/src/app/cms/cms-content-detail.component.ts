import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';

// Service needed to get the result
import { CMSContentDetailOutput, CMSServiceProxy} from '@shared/service-proxies/service-proxies';

import * as _ from 'lodash';

@Component({
    templateUrl: './cms-content-detail.component.html',
    animations: [appModuleAnimation()]
})

export class CMSContentDetailComponent extends AppComponentBase implements OnInit {

    //
    CMSContent: CMSContentDetailOutput = new CMSContentDetailOutput();
    pageId: number;

    constructor(
        injector: Injector,
        private _CMSService: CMSServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    //
    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.pageId = params['pageId'];
        });
        this.loadCMSContent();
    }

    //
    loadCMSContent() {
        console.log('Loading CMS content now...');
        this._CMSService.getDetailAsync(this.pageId)
            .subscribe((result: CMSContentDetailOutput) => {
                this.CMSContent = result;
            });
    }
}
