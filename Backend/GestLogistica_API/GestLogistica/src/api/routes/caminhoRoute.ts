import { Router } from 'express';
import { celebrate, Joi } from 'celebrate';

import { Container } from 'typedi';
import ICaminhoController from '../../controllers/IControllers/ICaminhoController'; 

import config from "../../../config";

const route = Router();

export default (app: Router) => {
  app.use('/caminhos', route);

  const ctrl = Container.get(config.controllers.caminho.name) as ICaminhoController;

  route.post('',
    celebrate({
      body: Joi.object({
        armazemChegadaId: Joi.string().required(),
        armazemPartidaId: Joi.string().required(),
        distancia: Joi.number().required(),
        energia: Joi.string().required(),
        tempo: Joi.string().required(),
        tmpCarregamento: Joi.string().required(),
      })
    }),
    (req, res, next) => ctrl.createCaminho(req, res, next) );

  route.put('',
    celebrate({
      body: Joi.object({
        id: Joi.string().required(),
        armazemChegadaId: Joi.string().required(),
        armazemPartidaId: Joi.string().required(),
        distancia: Joi.number().required(),
        energia: Joi.string().required(),
        tempo: Joi.string().required(),
        tmpCarregamento: Joi.string().required(),
      }),
    }),
    (req, res, next) => ctrl.updateCaminho(req, res, next) );

  route.delete('',
    celebrate({
      body: Joi.object({
        id: Joi.string().required(),
      }),
    }),
    (req, res, next) => ctrl.apagaCaminho(req, res, next) );

};