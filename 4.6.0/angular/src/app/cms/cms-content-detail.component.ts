import { Component, OnInit, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { EventDetailOutput, CMSServiceProxy} from '@shared/service-proxies/service-proxies';

import * as _ from 'lodash';

@Component({
    templateUrl: './cms-content-detail.component.html',
    animations: [appModuleAnimation()]
})

export class EventDetailComponent extends AppComponentBase implements OnInit {

    event: EventDetailOutput = new EventDetailOutput();
    pageId: number;

    constructor(
        injector: Injector,
        private _CMSService: CMSServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.pageId = params['pageId'];
        });
        this.loadCMSContent();
    }

    loadCMSContent() {
        console.log('loading CMS content now...')
        this._CMSService.getDetailAsync(this.pageId)
            .subscribe((result: EventDetailOutput) => {
                this.event = result;
            });
    }
}
