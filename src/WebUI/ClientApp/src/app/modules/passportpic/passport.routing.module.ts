import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PassportpicComponent } from './passportpic.component';
import { AuthorizeGuard } from '../../../api-authorization/authorize.guard';
import { UploadpageComponent } from './pages/uploadpage/uploadpage.component';
const routes: Routes = [
    {
        path: '',
        component: PassportpicComponent,
        children: [
            { path: '', redirectTo: 'passport', pathMatch: 'full' },
            { path: 'passport', component: UploadpageComponent, canActivate: [AuthorizeGuard] },
            { path: '**', redirectTo: '/404' },

        ],
    },
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class PassportpicRoutingModule { }
